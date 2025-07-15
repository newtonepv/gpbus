# GPBus for drivers

## Description
This is an app made with the objective of: 
- Updating public buses locations in real time.

<hr>

## Contents
- [How to drive a bus](#how-to-drive-a-bus).
- [Features](#features)
- [Pending Features](#pending-features)
- [Installing & Running](#installing-and-running)

<hr>

## Features
### Login page
- Driver autentication.
### Home page
- Bus selection.
- Driver localization.
- Updating bus position.
- Bus and driver assignments
### Database level
Buses and drivers have a many-to-many relation, becouse each driver is assigned to drive a group of buses and each bus is assigned to be driven by a group of drivers, here is an image of the busassigment relational table.



<hr>

## Pending Features
- Running on mobile emulator.

<hr>

## Installing and Running
### Pre-requisites
(Do not require android studio).
- Flutter & Dart (SDK) version higher than 3.0.0
- Chrome browser.
### Installling Steps
- Clone the repository:
  ```bash
  git clone https://github.com/newtonepv/gpbus_mobile.git
  cd gpbus_mobile
  ```
- Install dependencies:
  ```bash
  cd driver_app
  flutter pub get
  ```
### Running Steps
- Run the app on chrome:
  ```bash
  flutter run -d chrome
  ```
## How to drive a bus
