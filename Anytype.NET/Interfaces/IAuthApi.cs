namespace Anytype.NET.Interfaces;

/// <summary>
/// Provides methods to interact with Anytype auth endpoints.
/// </summary>
public interface IAuthApi
{
    /// <summary>
    /// Generates a one-time authentication challenge for the specified app.
    /// The challenge ID is required to obtain an API key.
    /// </summary>
    /// <param name="appName">
    /// The name of the app that is requesting the challenge.
    /// </param>
    /// <returns>The challenge id associated with the displayed code and needed to solve the challenge for api_key.</returns>
    Task<string> CreateChallengeAsync(string appName);

    /// <summary>
    /// Solves a previously generated challenge to obtain an API key.
    /// </summary>
    /// <param name="challengeId">The challenge id associated with the previously displayed code.</param>
    /// <param name="code">The 4-digit code retrieved from Anytype Desktop app.</param>
    /// <returns>The api key used to authenticate requests.</returns>
    Task<string> CreateApiKeyAsync(string challengeId, string code);
}
