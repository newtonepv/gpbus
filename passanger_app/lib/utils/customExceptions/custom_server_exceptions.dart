class CustomServerFullException implements Exception {
  final String message;
  CustomServerFullException(this.message);
  
  @override
  String toString() => message;
}