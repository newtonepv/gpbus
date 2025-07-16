class CustomNavigatedToLoginPageException implements Exception {
  final String message;
  CustomNavigatedToLoginPageException(this.message);
  
  @override
  String toString() => message;
}

class Custom409Exception implements Exception {
  final String message;
  Custom409Exception(this.message);
  
  @override
  String toString() => message;
}