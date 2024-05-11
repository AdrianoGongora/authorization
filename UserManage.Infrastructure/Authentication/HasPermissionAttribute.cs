using Microsoft.AspNetCore.Authorization;

namespace UserManage.Infrastructure.Authentication;

public sealed class HasPermissionAttribute(Permission permission) : 
    AuthorizeAttribute(policy: permission.ToString());