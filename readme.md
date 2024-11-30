# ValveStopTheFuckingStreams

## Description
**ValveStopTheFuckingStreams** is a simple Windows application designed to block annoying tournament streams in the main menu of CS2. It modifies the system's `hosts` file to redirect specific Steam content domains to `127.0.0.1`, effectively preventing the unwanted streams from loading. The application also provides functionality to clear these entries from the `hosts` file when no longer needed.

## Features
- Automatically fetches all relevant Steam content subdomains and blocks them by adding entries to the `hosts` file.
- Tracks the number of blocked domains.
- Provides an option to clear all blocked domains from the `hosts` file.

## How it Works
1. Fetches subdomains related to `steamcontent.com` from a public source.
2. Appends `127.0.0.1` entries for each domain to the `hosts` file.
3. Offers a "Clear" button to remove previously added entries.

## Warning
- Administrator privileges are required to modify the `hosts` file.
- Use at your own risk. Modifying the `hosts` file can impact your network configuration.

---

## Описание
**ValveStopTheFuckingStreams** — это простое приложение для Windows, которое блокирует раздражающие трансляции турниров в главном меню CS2. Оно изменяет файл `hosts` вашей системы, перенаправляя определенные домены Steam на `127.0.0.1`, тем самым предотвращая загрузку нежелательных трансляций. Программа также предоставляет возможность очистить файл `hosts` от этих записей, когда они больше не нужны.

## Функциональность
- Автоматически получает все связанные субдомены Steam и блокирует их, добавляя записи в файл `hosts`.
- Отслеживает количество заблокированных доменов.
- Предоставляет возможность очистить все заблокированные домены из файла `hosts`.

## Как это работает
1. Получает субдомены, связанные с `steamcontent.com`, из публичного источника.
2. Добавляет записи вида `127.0.0.1` для каждого домена в файл `hosts`.
3. Предлагает кнопку "Очистить" для удаления ранее добавленных записей.

## Предупреждение
- Для изменения файла `hosts` требуются права администратора.
- Используйте на свой страх и риск. Изменение файла `hosts` может повлиять на конфигурацию сети.
