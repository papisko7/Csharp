using MvcApp.Tests.Infrastructure;

namespace MvcApp.Integration.Handshake;

public class ApiHandshakeTests : IClassFixture<CustomWebApplicationFactory>
{
	private readonly HttpClient _client;

	public ApiHandshakeTests(CustomWebApplicationFactory factory)
	{
		_client = factory.CreateClient();
	}

	[Theory]
	[InlineData("/api/students")]
	[InlineData("/api/groups")]
	public async Task Endpoints_WhenRequested_ReturnsSuccessAndJson(string url)
	{
		// Act
		var response = await _client.GetAsync(url);

		// Assert
		response.EnsureSuccessStatusCode();

		var contentType = response.Content.Headers.ContentType?.ToString();
		Assert.NotNull(contentType);
		Assert.Contains("application/json", contentType);
	}
}