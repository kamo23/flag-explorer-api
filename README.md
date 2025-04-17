
---

### 📁 `flag-explorer-api/README.md`

```md
# 🧠 Flag Explorer Api

This is the api backend for the **Flag Explorer App**, built using ASP.NET Core 8. It serves country data to the Angular frontend.

---

## 🚀 Features

- ✅ REST API with endpoints to retrieve countries and country details
- 📄 Swagger/OpenAPI documentation
- 🧪 Unit and integration tests with xUnit
- 🐳 Docker support
- 🔄 CI/CD using GitHub Actions

---

## 🛠 Tech Stack

- [.NET 8](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-8)
- [xUnit](https://xunit.net/)
- [Swashbuckle (Swagger)](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
- [Docker](https://www.docker.com/)
- [GitHub Actions](https://docs.github.com/en/actions)

---

## 📁 Project Structure

flag-explorer-api/ ├── src/ │ └── FlagExplorer.API/ # Main Web API ├── tests/ │ └── FlagExplorer.Tests/ # Unit/Integration Tests ├── .github/workflows/ci.yml ├── Dockerfile └── README.md

dotnet run --project src/FlagExplorer.API


dotnet test


<a href="http://localhost:7001/swagger" rel="noreferrer noopener" title="http://localhost:7001/swagger" target="_blank">http://localhost:7001/swagger</a>

docker build -t flag-explorer-api .


docker run -p 7001:7001 flag-explorer-api
