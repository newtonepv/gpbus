# GPBus for passangers

## Description
This is an app made with the objective of: 
- Tracking public buses in real time.
- Reading, making and rating comments about public buses.

<hr>

## Features
### Login page
- User autentication.
### Register page
- User creation.
### Home page
- Map for locations visualization
- Bus selection
- Selected bus route visualization in the map.
- Selected bus position visualization in the map.
- Mooving bus nº200.\n 
Updating buses location is normally only allowed for drivers (using the driver_app) but, since this makes the
previous feature depend on the someone using the driver_app to moove the selected bus, we decided to make a button that,
when pressed, makes the bus nº200 moove following the route designed to it. The following image indicates with an arrow
 where is that button in the home page:

<p>
  <img url="../readme_images/moove_bus_200.jpeg" alt="moove bus 200 button ilustration">
</p>

- User localization in the map.
- Bus selection.
- Bus comments visualization, rating and submiting.

<hr>

## Pending Features
- Running on mobile emulator.
- Language selection (only portuguese for now).
- Alarms for when a selected bus passes by a selected region.
- User password recovery by email.
- Gamefication.
- Dark mode.
- Favorite buses.

<hr>

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
