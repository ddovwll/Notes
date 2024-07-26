using Notes.Core.Models;
using Notes.Web.Models.RequestModels;

namespace Notes.Web.Mappers;

public static class UserRequestToUser
{
    public static User Map(UserRequest userRequest)
    {
        return new User()
        {
            Name = userRequest.Name,
            Password = userRequest.Password,
            Salt = userRequest.Salt
        };
    }
}