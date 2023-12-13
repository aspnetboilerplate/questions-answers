FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/QuestionsAnswers.Web.Host/QuestionsAnswers.Web.Host.csproj", "src/QuestionsAnswers.Web.Host/"]
COPY ["src/QuestionsAnswers.Web.Core/QuestionsAnswers.Web.Core.csproj", "src/QuestionsAnswers.Web.Core/"]
COPY ["src/QuestionsAnswers.Application/QuestionsAnswers.Application.csproj", "src/QuestionsAnswers.Application/"]
COPY ["src/QuestionsAnswers.Core/QuestionsAnswers.Core.csproj", "src/QuestionsAnswers.Core/"]
COPY ["src/QuestionsAnswers.EntityFrameworkCore/QuestionsAnswers.EntityFrameworkCore.csproj", "src/QuestionsAnswers.EntityFrameworkCore/"]
WORKDIR "/src/src/QuestionsAnswers.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/QuestionsAnswers.Web.Host", "src/QuestionsAnswers.Web.Host"]
COPY ["src/QuestionsAnswers.Web.Core", "src/QuestionsAnswers.Web.Core"]
COPY ["src/QuestionsAnswers.Application", "src/QuestionsAnswers.Application"]
COPY ["src/QuestionsAnswers.Core", "src/QuestionsAnswers.Core"]
COPY ["src/QuestionsAnswers.EntityFrameworkCore", "src/QuestionsAnswers.EntityFrameworkCore"]
WORKDIR "/src/src/QuestionsAnswers.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "QuestionsAnswers.Web.Host.dll"]
