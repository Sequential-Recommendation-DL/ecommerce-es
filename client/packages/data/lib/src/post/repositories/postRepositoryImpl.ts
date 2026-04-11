import { PostDisplay, PostRepository } from "@packages/domain";
import {
  Either,
  Failure,
  left,
  right,
  mapExceptionToFailure
} from "@packages/core";
import { PostRemoteDataSource } from "../datasources/postRemoteDataSource";

class PostRepositoryImpl implements PostRepository {
  constructor(private postRemoteDataSource: PostRemoteDataSource) {}
  async getPosts({
    offset,
    limit
  }: {
    offset: number;
    limit: number;
  }): Promise<Either<Failure, PostDisplay[]>> {
    try {
      const posts = await this.postRemoteDataSource.getPosts(offset, limit);
      return right(posts);
    } catch (e) {
      return left(mapExceptionToFailure(e));
    }
  }
}

export { PostRepositoryImpl };
