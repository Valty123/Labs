FROM microsoft/dotnet:2.1-sdk as compiler
COPY . /root/src
RUN dotnet publish -c Release -v Detailed -o /root/publishedAppLR6 /root/src

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1 as base
COPY --from=compiler /root/publishedAppLR6 /root/publishedAppLR6
WORKDIR /root/publishedAppLR6
CMD ["dotnet", "LAB1.dll"]