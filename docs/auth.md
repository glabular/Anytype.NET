> [!IMPORTANT]
> The latest API version is used for all authentication endpoints.

## Create Challenge

Generates a one-time authentication challenge for the specified app. The challenge ID is required to obtain an API key.

```csharp
var challengeId = await AnytypeClient.Auth.CreateChallengeAsync("MyApp");

Console.WriteLine($"Challenge created: {challengeId}");
Console.WriteLine("Please check your Anytype Desktop app for the 4-digit code.");
```

### Parameters

- **appName** (string): The name of the app that is requesting the challenge

### Returns

- `string` — the challenge ID associated with the displayed code and needed to solve the challenge for API key.

## Create API Key

Solves a previously generated challenge to obtain an API key using the 4-digit code from the Anytype Desktop app.

```csharp
// After getting the 4-digit code from Anytype Desktop app
var code = "1234"; // Replace with actual code from desktop app
var apiKey = await AnytypeClient.Auth.CreateApiKeyAsync(challengeId, code);

Console.WriteLine($"API Key obtained: {apiKey}");

// Now you can use the API key to create an authenticated client
var client = new AnytypeClient(apiKey);
```

### Parameters

- **challengeId** (string): The challenge ID associated with the previously displayed code
- **code** (string): The 4-digit code retrieved from Anytype Desktop app

### Returns

- `string` — the API key used to authenticate requests.

## Authentication Flow

The typical authentication flow involves these steps:

```csharp
// Step 1: Create a challenge
var challengeId = await AnytypeClient.Auth.CreateChallengeAsync("MyApplication");

// Step 2: User checks Anytype Desktop app for the 4-digit code
Console.WriteLine("Please check your Anytype Desktop app and enter the 4-digit code:");
var userCode = Console.ReadLine(); // Get code from user input

// Step 3: Exchange challenge and code for API key
var apiKey = await AnytypeClient.Auth.CreateApiKeyAsync(challengeId, userCode);

// Step 4: Create authenticated client
var authenticatedClient = new AnytypeClient(apiKey);

// Step 5: Use the client for API calls
var spaces = await authenticatedClient.Spaces.ListAsync();
```