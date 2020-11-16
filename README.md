# UtcDateTime

C# library class for work with DateTime through timezones

## Motivation

Default C# struct DateTime is fine when you work all in UTC or all in localtime. It starts to be a bit confusing when you work in multiple timezones. This lib should be more clear and easy-to-use.

## High level

This struct represent single moment all over the Earth (or Universe). You don't care about timezone. There are two moment when you do - "import" (creating, parsing) and "export" (ToString, GetHours, etc.).
