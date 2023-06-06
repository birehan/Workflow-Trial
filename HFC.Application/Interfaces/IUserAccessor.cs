using HFC.Domain;

namespace HFC.Application.Interfaces
{
       public interface IUserAccessor
    {
         string GetUsername();

         Task<AppUser>  GetCurrentUser();

    }
}