class AppException extends Error {
  constructor(message: string) {
    super(message);
    this.name = "AppException";
  }
}

class AuthenticationException extends AppException {
  constructor(message: string) {
    super(message);
  }
}

class DatabaseException extends AppException {
  constructor(message: string) {
    super(message);
  }
}

class PermissionException extends DatabaseException {
  constructor(message: string) {
    super(message);
  }
}

class NotFoundException extends DatabaseException {
  constructor(message: string) {
    super(message);
  }
}

class NetworkException extends AppException {
  constructor() {
    super("Please check your internet connection");
  }
}

class UnknownException extends AppException {
  constructor() {
    super("An unknown error occurred.");
  }
}

export {
  AuthenticationException,
  DatabaseException,
  PermissionException,
  NotFoundException,
  NetworkException,
  UnknownException
};
