FROM mcr.microsoft.com/dotnet/core/aspnet
				
COPY ./EMSPracticeAPI/bin/Release/netcoreapp2.1/publish /app
WORKDIR /app
EXPOSE 80
CMD ["dotnet", "EMSPracticeAPI.dll"]
#this is test of webhook
