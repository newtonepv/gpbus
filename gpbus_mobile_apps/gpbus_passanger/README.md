# GPBus for passengers

## Description
This is an app made with the objective of: 
- Tracking public buses in real time.
- Reading, making and rating comments about public buses.

<hr>

## Features
### Login page
- User authentication.
### Register page
- User creation.
### Home page
- Map for location visualization
- Bus selection
- Selected bus route visualization in the map.
- Selected bus position visualization in the map.
- Moving bus nº200.\n 
Updating buses location is normally only allowed for drivers (using the driver_app) but, since this makes the
previous feature depend on the someone using the driver_app to moove the selected bus, we decided to make a button that,
when pressed, makes the bus nº200 moove following the route designed to it. The following image indicates with an arrow
 where is that button in the home page:

<p align="center" style="margin: 0; padding: 0;">
  <img src="../readme_images/moove_bus_200.jpeg" alt="moove bus 200 button ilustration" width="400">
</p>

- User localization in the map.
- Bus selection.
- Bus comments visualization, rating and submission.

<hr>

## Pending features
- Language selection (only portuguese for now).
- Alerts for when a selected bus passes by a selected region.
- User password recovery by email.
- Gamification.
- Dark mode.
- Favorite buses.

<hr>

## Installing & running
### Prerequisites
(Do not require android studio).
- Flutter & Dart (SDK) version higher than 3.0.0.
- Chrome browser.
### Installling steps
- Clone the repository:
  ```bash
  git clone https://github.com/newtonepv/gpbus_mobile.git
  cd gpbus_mobile
  ```
- Install dependencies:
  ```bash
  cd gpbus_passanger
  flutter pub get
  ```
### Running steps
#### Running the app on chrome:
 ```bash
 flutter run -d chrome
 ```
#### Enablnig the app to run on a Android device:
- Enable developer mode.
- Enable USB Debugging.
- Connect via USB.

#### Enablnig the app to run on a IOS device:
- Connect via USB or wireless.
- Trust developer certificate.

#### Running the app on mobile device:
```bash
  flutter run
  ```
