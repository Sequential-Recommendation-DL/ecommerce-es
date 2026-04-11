import { Either } from "../constants/either";
import { Failure } from "../errors/failures";

interface UseCase<ReturnType, ParamsType> {
  execute(params: ParamsType): Promise<Either<Failure, ReturnType>>;
}

type NoParams = {};

export type { UseCase, NoParams };
