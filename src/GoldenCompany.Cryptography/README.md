##  GoldenCompany

Nuget Packages

-## Cryptography

For use Cryptography, you must import GoldenCompany and set value key.
Sample:

```csharp
public void YourMethod()
{

    Cryptography.SetKey("your-key")

    var password = "Abcdefgh@12345";

    var passwordEncrypted = Cryptography.Encrypt(password);

    var passwordDecrypted = Cryptography.Decrypt(passwordEncrypted);
}
```
