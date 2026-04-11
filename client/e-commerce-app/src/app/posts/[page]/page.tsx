"use client";

import { usePosts } from "@/hooks/usePosts";
import Link from "next/link";
import { useParams } from "next/navigation";

const POSTS_PER_PAGE = 10;

export default function PostsPageWithPagination() {
  const params = useParams();
  const pageStr = Array.isArray(params.page)
    ? params.page[0]
    : (params.page as string) || "1";
  const page = Math.max(1, parseInt(pageStr) || 1);
  const offset = (page - 1) * POSTS_PER_PAGE;
  const { posts, loading, error } = usePosts(offset, POSTS_PER_PAGE);
  const previousPage = page > 1 ? page - 1 : null;
  const nextPage = posts.length === POSTS_PER_PAGE ? page + 1 : null;

  return (
    <main className='min-h-screen bg-white dark:bg-black p-8'>
      <div className='max-w-4xl mx-auto'>
        <h1 className='text-4xl font-bold text-black dark:text-white mb-8'>
          Posts from JSONPlaceholder
        </h1>

        {loading && (
          <div className='text-center py-12'>
            <p className='text-gray-600 dark:text-gray-400 text-lg'>
              Loading posts...
            </p>
          </div>
        )}

        {error && (
          <div className='bg-red-50 dark:bg-red-900/20 border border-red-200 dark:border-red-800 rounded-lg p-4 mb-8'>
            <p className='text-red-800 dark:text-red-200'>Error: {error}</p>
          </div>
        )}

        {!loading && !error && posts.length > 0 && (
          <>
            <div className='grid gap-6'>
              {posts.map((post) => (
                <article
                  key={post.id}
                  className='bg-gray-50 dark:bg-gray-900 border border-gray-200 dark:border-gray-800 rounded-lg p-6 hover:shadow-lg transition-shadow'>
                  <div className='flex items-start justify-between mb-3'>
                    <h2 className='text-xl font-semibold text-black dark:text-white pr-4'>
                      {post.title}
                    </h2>
                    <span className='shrink-0 text-sm font-medium text-gray-500 dark:text-gray-400'>
                      User {post.userId}
                    </span>
                  </div>
                  <p className='text-gray-700 dark:text-gray-300 leading-relaxed'>
                    {post.body}
                  </p>
                </article>
              ))}
            </div>
          </>
        )}

        {!loading && !error && posts.length === 0 && (
          <div className='text-center py-12'>
            <p className='text-gray-600 dark:text-gray-400 text-lg'>
              No posts found
            </p>
          </div>
        )}

        {/* Pagination Controls */}
        <div className='flex items-center justify-between gap-4 mt-12'>
          {previousPage ? (
            <Link
              href={`/posts/${previousPage}`}
              className='px-6 py-3 bg-blue-600 hover:bg-blue-700 text-white rounded-lg transition-colors'>
              ← Previous Page
            </Link>
          ) : (
            <div className='px-6 py-3 bg-gray-300 dark:bg-gray-700 text-gray-500 dark:text-gray-400 rounded-lg cursor-not-allowed'>
              ← Previous Page
            </div>
          )}

          <span className='text-gray-600 dark:text-gray-400 font-medium'>
            Page {page}
          </span>

          {nextPage ? (
            <Link
              href={`/posts/${nextPage}`}
              className='px-6 py-3 bg-blue-600 hover:bg-blue-700 text-white rounded-lg transition-colors'>
              Next Page →
            </Link>
          ) : (
            <div className='px-6 py-3 bg-gray-300 dark:bg-gray-700 text-gray-500 dark:text-gray-400 rounded-lg cursor-not-allowed'>
              Next Page →
            </div>
          )}
        </div>
      </div>
    </main>
  );
}
