import { PostDisplayModel } from "../model/postDisplayModel";

interface PostRemoteDataSource {
  getPosts(offset: number, limit: number): Promise<PostDisplayModel[]>;
}

export type { PostRemoteDataSource };
