import { Either, Failure, UseCase } from "@packages/core";
import { PostDisplay } from "../entities/entities";
import { PostRepository } from "../repositories/postRepository";

class GetPostsParams {
  constructor(
    public offset: number,
    public limit: number = 10
  ) {
    this.offset = offset;
    this.limit = limit;
  }
}

class GetPostsUsecase implements UseCase<PostDisplay[], GetPostsParams> {
  constructor(private postRepository: PostRepository) {}

  async execute(
    params: GetPostsParams
  ): Promise<Either<Failure, PostDisplay[]>> {
    return await this.postRepository.getPosts({
      offset: params.offset,
      limit: params.limit
    });
  }
}

export { GetPostsUsecase };
