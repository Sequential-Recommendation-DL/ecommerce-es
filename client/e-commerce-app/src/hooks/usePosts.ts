import { useEffect, useState, useCallback } from "react";
import { PostDisplay } from "@packages/domain";
import { getErrorMessage } from "@packages/core";

interface UsePostsResult {
  posts: PostDisplay[];
  loading: boolean;
  error: string | null;
  refetch: () => Promise<void>;
}

export function usePosts(offset = 0, limit = 10): UsePostsResult {
  const [posts, setPosts] = useState<PostDisplay[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  const fetchPosts = useCallback(async () => {
    try {
      setLoading(true);
      setError(null);

      const params = new URLSearchParams({
        offset: offset.toString(),
        limit: limit.toString()
      });

      const response = await fetch(`/api/posts?${params}`);
      const data = await response.json();

      if (data.status === 200) {
        setPosts(data.data);
      } else {
        setError(data.error);
      }
    } catch (err) {
      setError(getErrorMessage(err));
    } finally {
      setLoading(false);
    }
  }, [offset, limit]);

  useEffect(() => {
    fetchPosts();
  }, [fetchPosts]);

  return {
    posts,
    loading,
    error,
    refetch: fetchPosts
  };
}
