
using AutoMapper;
using HFC.Application.Contracts.Persistence;
using HFC.Application.Features.Staffs.CQRS.Commands;
using HFC.Application.Features.Staffs.DTOs.Validators;
using HFC.Application.Responses;
using MediatR;
using HFC.Domain;
using HFC.Application.Interfaces;

namespace HFC.Application.Features.Staffs.CQRS.Handlers
{
    public class CreateStaffCommandHandler : IRequestHandler<CreateStaffCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private readonly IPhotoAccessor _photoAccessor;


        public CreateStaffCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IPhotoAccessor photoAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _photoAccessor = photoAccessor;

        }

        public async Task<Result<Guid>> Handle(CreateStaffCommand request, CancellationToken cancellationToken)
        {

            try
            {
                Console.WriteLine("I am here Create handler");

                var validator = new CreateStaffDtoValidator();
                var validationResult = await validator.ValidateAsync(request.StaffDto);

                if (!validationResult.IsValid)
                    return Result<Guid>.Failure(validationResult.Errors[0].ErrorMessage);


                var Staff = _mapper.Map<Staff>(request.StaffDto);
                var photoUploadResult = await _photoAccessor.AddPhoto(request.StaffDto.File);

                if (photoUploadResult == null)
                    return Result<Guid>.Failure("Creation Failed");

                Staff.Photo = new Photo
                {
                    Url = photoUploadResult.Url,
                    Id = photoUploadResult.PublicId
                };

                await _unitOfWork.StaffRepository.Add(Staff);

                if (await _unitOfWork.Save() > 0)
                    return Result<Guid>.Success(Staff.Id);

                return Result<Guid>.Failure("Creation Failed");
            }
            catch (Exception ex)
            {
                return Result<Guid>.Failure($"Creation Failed: {ex.Message}");

            }
        }
    }


}
