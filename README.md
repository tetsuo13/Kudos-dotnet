# Kudos Dot Net

[![Build status](https://ci.appveyor.com/api/projects/status/v0g2xmlmh5lgplmw/branch/master?svg=true)](https://ci.appveyor.com/project/tetsuo13/kudos-dotnet)

Kudos Dot Net is a .NET client for the [SCIM](http://www.simplecloud.info/) User
Provisioning API in [Kudos](http://kudosnow.com/).

The Kudos API documentation can be found on your company's instance at
https://your_company_name.kudosnow.com/api_docs/scim

## Installation

Kudos Dot Net can be installed via the NuGet UI (as
[Kudos Not Net]()) or via the NuGet package manager console:

```PowerShell
PM> Install-Package KudosDotNet
```

## Usage

You'll need an Authorization Token before you can use this library. An
administrator account can get it at
https://your_company_name.kudosnow.com/admin/api/

```C#
using Kudos;
...
IKudosApi kudos = new KudosApi(AuthorizationToken);
```

### Users

Get a list of all users in the organization:

```C#
Users users = await kudos.GetUsersAsync();
```

Get a single user:

```C#
User user = await kudos.GetUserAsync(42);
```

Create a new user. The only requirement is that the `User.UserName` (their
email address) is set.

```C#
User newUser = new User()
{
    UserName = "foo@your-company-name.com"
};
User response = await kudos.CreateUserAsync(newUser);
```

Update an existing user:

```C#
UpdateUser update = new UpdateUser()
{
    Kudos = new Kudos.Models.Extensions.UpdateKudosExtension()
    {
        DateOfBirth = new DateTime(1966, 3, 17)
    }
};
User result = await kudos.UpdateUserAsync(42, update);
```

Delete an existing user.

```C#
await kudos.DeleteUser(42);
```

### Groups

Get a list of all groups in the organization:

```C#
Groups groups = await kudos.GetGroupsAsync();
```

Get a single group:

```C#
Group group = await kudos.GetGroupAsync(42);
```

Delete an existing group:

```C#
await kudos.DeleteGroupAsync(42);
```

## Endpoints Missing

- Groups
  - Create
  - Update

**Note:** The SCIM User Provisioning API in Kudos provides the ability to
replace an existing user or group (using PATCH) but that's been omitted on
purpose in favor of the corresponding update call.
