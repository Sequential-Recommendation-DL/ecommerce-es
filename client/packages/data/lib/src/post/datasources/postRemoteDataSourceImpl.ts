import { PostDisplayModel } from "../model/postDisplayModel";
import { PostRemoteDataSource } from "./postRemoteDataSource";
import { NetworkException, DatabaseException } from "@packages/core";

class PostRemoteDataSourceImpl implements PostRemoteDataSource {
  private readonly baseUrl = "https://jsonplaceholder.typicode.com";

  async getPosts(offset: number, limit: number): Promise<PostDisplayModel[]> {
    try {
      const params = new URLSearchParams({
        _start: offset.toString(),
        _limit: limit.toString()
      });

      const response = await fetch(`${this.baseUrl}/posts?${params}`);

      if (!response.ok) {
        throw new DatabaseException(`API Error: ${response.statusText}`);
      }

      const data = await response.json();

      if (!Array.isArray(data)) {
        throw new DatabaseException("Invalid response format");
      }

      return data.map((post) => PostDisplayModel.fromJson(post));
    } catch (error) {
      if (error instanceof TypeError) {
        throw new NetworkException();
      }
      throw error;
    }
  }
}

export { PostRemoteDataSourceImpl };
