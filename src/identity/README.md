# Identity Management

Enables an extendable identity service to manages users, password hashing and profile data.

## Identity Password Hashing
Implements a salted HMAC-SHA256 password hashing.
>**_Caution:_** Please note that we are not security experts. Use at your own risk. 

## Getting Started
```CSharp
static void Main()
{
    var identityProvider = new IdentityProvider();
    
    var username = "b.smith";  //User name must be at least 6 characters long
    var user = new IdentityUser(username);

    var password = "password"; //Password must be at least 8 characters long
    var results1 = identityProvider.Create(user, password);
    Debug.WriteLine(results1.Succeeded);

    var expected = identityProvider.FindByName(username);
    Debug.WriteLine(user.Name);

    var results2 = identityProvider.VerifyPassword(user, password);
    Debug.WriteLine((results2.Succeeded);
}
```

## Custom IIdentityUser Example

```CSharp
static void Main()
{
    var identityProvider = new IdentityProvider();

    var username = "b.smith";
    var user = new User(username, "Bob", "Smith");

    var password = "password";
    var results1 = identityProvider.Create(user, password);
    Debug.WriteLine(results1.Succeeded);

    var expected = (User)_identityProvider.FindByName(username);
    Debug.WriteLine(user.Name);

    var results2 = identityProvider.VerifyPassword(user, password);
    Debug.WriteLine((results2.Succeeded);
}

public class User : IIdentityUser
{
    public User(string name, string firstName, string lastName)
    {
        Id = DateTime.Now.Ticks.ToString();
        Name = name;    
        FirstName = firstName;
        LastName = lastName;
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
}
```

## TinyCLR Packages
Install release package from [NuGet](https://www.nuget.org/packages?q=bytewizer.tinyclr) or using the Package Manager Console :
```powershell
PM> Install-Package Bytewizer.TinyCLR.Identity
```