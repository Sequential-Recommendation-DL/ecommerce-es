import { Either, Failure } from "@packages/core";
import { PostDisplay } from "../entities/entities";

interface PostRepository {
  getPosts({
    offset,
    limit
  }: {
    offset: number;
    limit: number;
  }): Promise<Either<Failure, PostDisplay[]>>;
}

export { PostRepository };
