import nextConfig from "eslint-config-next";

const nextAppConfig = [
  ...nextConfig,
  {
    ignores: [
      ".next/**",
      "out/**",
      "build/**",
      "dist/**",
      "coverage/**",
      ".git/**",
      "node_modules/**"
    ]
  }
];

export default nextAppConfig;
