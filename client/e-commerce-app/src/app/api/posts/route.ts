import { PostRemoteDataSourceImpl } from "@packages/data";
import { PostRepositoryImpl } from "@packages/data";
import { GetPostsUsecase } from "@packages/domain";

export async function GET(request: Request) {
  const { searchParams } = new URL(request.url);
  const offset = parseInt(searchParams.get("offset") || "0");
  const limit = parseInt(searchParams.get("limit") || "10");

  const dataSource = new PostRemoteDataSourceImpl();
  const repository = new PostRepositoryImpl(dataSource);
  const usecase = new GetPostsUsecase(repository);

  const result = await usecase.execute({
    offset,
    limit
  });

  if (result.type === "right") {
    return Response.json({ status: 200, data: result.value });
  } else {
    return Response.json({ error: result.value.message });
  }
}
