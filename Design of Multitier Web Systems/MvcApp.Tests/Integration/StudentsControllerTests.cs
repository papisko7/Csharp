using MvcApp.DTOs.Student_DTOs;
using MvcApp.Tests.Infrastructure;
using System.Net;
using System.Net.Http.Json;

namespace MvcApp.Tests.Integration;

public class StudentsControllerTests : IClassFixture<CustomWebApplicationFactory>
{
	private readonly HttpClient _client;

	public StudentsControllerTests(CustomWebApplicationFactory factory)
	{
		_client = factory.CreateClient();
	}

	[Fact]
	public async Task GetStudents_WhenDatabaseHasSeedData_ReturnsOkAndPopulatedList()
	{
		// Act
		var response = await _client.GetAsync("/api/students");

		// Assert
		Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		var students = await response.Content.ReadFromJsonAsync<List<StudentDto>>();
		Assert.NotNull(students);
		Assert.NotEmpty(students);
	}

	[Fact]
	public async Task PostStudent_WhenPayloadIsValid_ReturnsCreatedAndSavesToDatabase()
	{
		// Arrange
		var newStudent = new StudentDto
		{
			FirstName = "Janusz",
			LastName = "Nosacz",
			Age = 45,
			GroupId = 1
		};

		// Act
		var response = await _client.PostAsJsonAsync("/api/students", newStudent);

		// Assert
		Assert.Equal(HttpStatusCode.Created, response.StatusCode);
		var createdStudent = await response.Content.ReadFromJsonAsync<StudentDto>();
		Assert.NotNull(createdStudent);
		Assert.True(createdStudent.StudentId > 0);
		Assert.Equal("Janusz", createdStudent.FirstName);
	}

	[Fact]
	public async Task PostStudentWithGroup_WhenGroupDoesNotExist_ReturnsCreatedAndCreatesNewGroup()
	{
		// Arrange 
		var dto = new CreateStudentWithGroupDto
		{
			FirstName = "Zbigniew",
			LastName = "Kowalski",
			Age = 30,
			GroupName = "Zupełnie Nowa Grupa X"
		};

		// Act
		var response = await _client.PostAsJsonAsync("/api/students/with-group", dto);

		// Assert
		Assert.Equal(HttpStatusCode.Created, response.StatusCode);
		var createdStudent = await response.Content.ReadFromJsonAsync<StudentDto>();
		Assert.NotNull(createdStudent);
		Assert.True(createdStudent.GroupId > 0);
	}

	[Fact]
	public async Task PutStudent_WhenStudentExistsAndDataIsValid_ReturnsNoContentAndUpdatesDatabase()
	{
		// Arrange 
		var original = new StudentDto { FirstName = "Przed", LastName = "Edycją", Age = 20, GroupId = 1 };
		var postRes = await _client.PostAsJsonAsync("/api/students", original);
		var created = await postRes.Content.ReadFromJsonAsync<StudentDto>();

		created.FirstName = "Po";
		created.LastName = "Edycji";

		// Act
		var response = await _client.PutAsJsonAsync($"/api/students/{created.StudentId}", created);

		// Assert
		Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

		var getRes = await _client.GetAsync($"/api/students/{created.StudentId}");
		var updated = await getRes.Content.ReadFromJsonAsync<StudentDto>();
		Assert.Equal("Po", updated.FirstName);
	}

	[Fact]
	public async Task DeleteStudent_WhenStudentExists_ReturnsNoContentAndRemovesFromDatabase()
	{
		// Arrange 
		var studentToDelete = new StudentDto { FirstName = "Do", LastName = "Usunięcia", Age = 22, GroupId = 1 };
		var postRes = await _client.PostAsJsonAsync("/api/students", studentToDelete);
		var created = await postRes.Content.ReadFromJsonAsync<StudentDto>();

		// Act
		var response = await _client.DeleteAsync($"/api/students/{created.StudentId}");

		// Assert
		Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

		var getRes = await _client.DeleteAsync($"/api/students/{created.StudentId}");
		Assert.Equal(HttpStatusCode.NotFound, getRes.StatusCode);
	}

	[Fact]
	public async Task GetStudent_WhenIdDoesNotExist_ReturnsNotFound()
	{
		// Arrange
		int nonExistentId = 999999;

		// Act
		var response = await _client.GetAsync($"/api/students/{nonExistentId}");

		// Assert
		Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
	}

	[Fact]
	public async Task PostStudent_WhenFirstNameIsEmpty_ReturnsBadRequest()
	{
		// Arrange 
		var invalidStudent = new StudentDto
		{
			FirstName = "", // Puste imię
			LastName = "Kowalski",
			Age = 20,
			GroupId = 1
		};

		// Act
		var response = await _client.PostAsJsonAsync("/api/students", invalidStudent);

		// Assert
		Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
	}

	[Fact]
	public async Task PutStudent_WhenIdInUrlAndBodyMesh_ReturnsBadRequest()
	{
		// Arrange
		int urlId = 5;
		var dto = new StudentDto { StudentId = 10, FirstName = "Jan", LastName = "Kos", Age = 21, GroupId = 1 };

		// Act
		var response = await _client.PutAsJsonAsync($"/api/students/{urlId}", dto);

		// Assert
		Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
	}
}