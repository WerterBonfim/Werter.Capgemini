FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.8-alpine3.12 as base
WORKDIR /app
EXPOSE 5100
EXPOSE 5101

FROM mcr.microsoft.com/dotnet/core/sdk:3.1.402-alpine3.12 AS build
WORKDIR /src

# Werter.Capgemini.WebApi


# Copia csproj e faz um restore de cada layer
COPY ["Werter.Capgemini.WebApi.csproj",  "Werter.Capgemini.WebApi/"]

RUN dotnet restore Werter.Capgemini.WebApi/Werter.Capgemini.WebApi.csproj

#Copia tudo 
COPY ["Werter.Capgemini.WebApi/",  "Werter.Capgemini.WebApi/"]



WORKDIR /src

RUN dotnet build Werter.Capgemini.WebApi/Werter.Capgemini.WebApi.csproj -c Release -o /app/b
FROM build as publish

RUN dotnet publish Werter.Capgemini.WebApi/Werter.Capgemini.WebApi.csproj -c Release -o /app/publish

#final 
FROM base as final
WORKDIR /app

# Install cultures (same approach as Alpine SDK image)
RUN apk add --no-cache icu-libs

# Disable the invariant mode (set in base image)
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Werter.Capgemini.WebApi.dll"]