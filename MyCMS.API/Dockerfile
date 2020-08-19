#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM registry.cn-hangzhou.aliyuncs.com/newbe36524/aspnet:3.1-buster-slim
#WORKDIR /app
#EXPOSE 80

#FROM registry.cn-hangzhou.aliyuncs.com/newbe36524/sdk:3.1-buster AS build
#WORKDIR /src
#COPY ["MyCMS.API/MyCMS.API.csproj", "MyCMS.API/"]
#COPY ["MyCMS.Infrastructure/MyCMS.Infrastructure.csproj", "MyCMS.Infrastructure/"]
#COPY ["MyCMS.Infrastructure.Core/MyCMS.Infrastructure.Core.csproj", "MyCMS.Infrastructure.Core/"]
#COPY ["MyCMS.Domain.Abstractions/MyCMS.Domain.Abstractions.csproj", "MyCMS.Domain.Abstractions/"]
#COPY ["MyCMS.Domain/MyCMS.Domain.csproj", "MyCMS.Domain/"]
#RUN dotnet restore "MyCMS.API/MyCMS.API.csproj"
#COPY . .
#WORKDIR "/src/MyCMS.API"
#RUN dotnet build "MyCMS.API.csproj" -c Release -o /app/build

#FROM build AS publish
#RUN dotnet publish "MyCMS.API.csproj" -c Release -o /app/publish

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#	ENTRYPOINT ["dotnet", "MyCMS.API.dll"]
RUN mkdir /publish
COPY ./mycms /publish
WORKDIR /publish
ENTRYPOINT ["dotnet", "MyCMS.API.dll"]