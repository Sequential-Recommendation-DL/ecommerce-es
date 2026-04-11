import {
  AppException,
  AuthenticationException,
  DatabaseException,
  NetworkException,
  NotFoundException,
  PermissionException
} from "../errors/exceptions";
import {
  AuthenticationFailure,
  NetworkFailure,
  NotFoundFailure,
  PermissionFailure,
  ServerFailure,
  UnknownFailure
} from "../errors/failures";

function mapExceptionToFailure(e: unknown) {
  if (!(e instanceof AppException)) {
    return new UnknownFailure();
  }

  switch (e.constructor) {
    case AuthenticationException:
      return new AuthenticationFailure(e.message);

    case PermissionException:
      return new PermissionFailure();

    case NotFoundException:
      return new NotFoundFailure();

    case DatabaseException:
      return new ServerFailure(e.message);

    case NetworkException:
      return new NetworkFailure();

    default:
      return new UnknownFailure();
  }
}

export { mapExceptionToFailure };
