C:\Users\user201-20\Desktop\CSharp-main>dotnet run --project .\src\MemoryLifecycle\MemoryLifecycle.csproj -c Release
=== КТ №43. Паттерн Dispose и IAsyncDisposable ===

1. Синхронный сценарий using (DatabaseConnection)
[DatabaseConnection 1] соединение открыто
[DatabaseConnection 1] запрос: SELECT * FROM Students
[DatabaseConnection 1] журнал запросов очищен (синхронно)
[DatabaseConnection 1] соединение закрыто (нативный ресурс)

2. Асинхронный сценарий await using (DatabaseConnection)
[DatabaseConnection 2] соединение открыто
[DatabaseConnection 2] запрос: SELECT * FROM Topics
[DatabaseConnection 2] журнал запросов очищен (асинхронно)
[DatabaseConnection 2] соединение закрыто (нативный ресурс)

3. Проверка GC.SuppressFinalize после using
[DatabaseConnection 3] соединение открыто
[DatabaseConnection 3] запрос: SELECT 1
[DatabaseConnection 3] журнал запросов очищен (синхронно)
[DatabaseConnection 3] соединение закрыто (нативный ресурс)
После сборки: сообщение финализатора отсутствует (ресурсы уже закрыты)

4. Финализатор без Dispose (DatabaseConnection)
[DatabaseConnection 4] соединение открыто
[DatabaseConnection 4] запрос: UPDATE Students SET Name = 'Test'
[DatabaseConnection 4] соединение закрыто (нативный ресурс)
После сборки: финализатор освободил только нативный ресурс

5. Синхронный и асинхронный FileBuffer
[FileBuffer 1] буфер открыт
[FileBuffer 1] записано 4 байт
[FileBuffer 1] буфер освобожден (синхронно)
[FileBuffer 1] нативный дескриптор закрыт
[FileBuffer 2] буфер открыт
[FileBuffer 2] записано 3 байт
[FileBuffer 2] буфер освобожден (асинхронно)
[FileBuffer 2] нативный дескриптор закрыт
