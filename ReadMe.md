# Pokémon EV Finder

## Building the App

### Android

-	Open .NET CLI
-	Navigate to the directory of the project "PokemonEffortValueFinder"
-	Create a keystore file with  
`keytool -genkey -v -keystore myapp.keystore -alias key -keyalg RSA -keysize 2048 -validity 10000`
-	Make sure the PokemonEffortValueFinder.csproj contains the following:  
    `<PropertyGroup Condition="$(TargetFramework.Contains('-android')) and '$(Configuration)' == 'Release'">
      <AndroidKeyStore>True</AndroidKeyStore>
      <AndroidSigningKeyStore>myapp.keystore</AndroidSigningKeyStore>
      <AndroidSigningKeyAlias>key</AndroidSigningKeyAlias>
      <AndroidSigningKeyPass></AndroidSigningKeyPass>
      <AndroidSigningStorePass></AndroidSigningStorePass>
     </PropertyGroup>`
-   Enter the following command (replace "mypassword" with your keystore password):  
    `dotnet publish -f:net7.0-android -c:Release /p:AndroidSigningKeyPass=mypassword /p:AndroidSigningStorePass=mypassword`
-   Your release directory now contains the .apk file

### Windows

#### MSIX-package

-   Use the publishing wizard included in Visual Studio

#### self-contained .exe

-   Open .NET CLI
-	Navigate to the directory of the project "PokemonEffortValueFinder"
-   Enter the following command:  
    `msbuild /restore /t:build /p:TargetFramework=net7.0-windows10.0.19041 /p:configuration=release /p:WindowsAppSDKSelfContained=true /p:Platform=x64 /p:WindowsPackageType=None /p:RuntimeIdentifier=win10-x64`
-   Your release directory now contains the .exe file as well as all the required files

You might have to change the target framework in the .Core.csproj file to the one referenced in the command above