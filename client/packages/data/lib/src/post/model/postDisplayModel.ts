import { PostDisplay } from "@packages/domain";

class PostDisplayModel {
  readonly userId: number;
  readonly id: number;
  readonly title: string;
  readonly body: string;

  constructor(userId: number, id: number, title: string, body: string) {
    this.userId = userId;
    this.id = id;
    this.title = title;
    this.body = body;
  }

  static fromJson(json: Record<string, unknown>): PostDisplay {
    return new PostDisplayModel(
      Number(json.userId),
      Number(json.id),
      String(json.title),
      String(json.body)
    );
  }
}

export { PostDisplayModel };
