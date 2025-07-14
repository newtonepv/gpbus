# GPBus for drivers

## Description
This is an app made with the objective of: 
- Updating public buses locations in real time.

## Features
### Login page
- Driver autentication.
### Home page
- Map for locations visualization
- User localization in the map.
- Bus selection.
- Bus route visualization in the map.
- Bus position visualization in the map.
- Bus comments visualization, rating and submiting.

## Pending Features
- Running on mobile emulator.
- Language selection (only portuguese for now).
- Alarms for when a selected bus passes by a selected region.
- User password recovery by email.
- Gamefication.
- Dark mode.
- Favorite buses.

## Installing & Running
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
  cd passanger_app
  flutter pub get
  ```
### Running Steps
- Run the app on chrome:
  ```bash
  flutter run -d chrome
  ```