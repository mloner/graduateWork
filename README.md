# Reporting Framework

## Структура
- CugReportsMS - сборщик модели отчета. Главный проект - Orchestrator.
- ChartGeneratorMS - генератор графиков
- ReportGeneratorMS - генератор файлов отчетов
- PdfReportTemplaterClient - клиент PDF Generator API - сервис генерации pdf файлов
- ReportConfigurationMS - сервис для инициации процесса генерации отчетов по расписанию
- SenderClient - клиент сервиса отправки файлов на почту
- WebApp - веб-приложение. Необходимо для получение ссылки на редактор шаблонов в сервисе PDF Generator API.

Проект залит одним коммитом, так как он находится в приватном репозитории Azure DevOps. Я скачал проект и залил его на github.
