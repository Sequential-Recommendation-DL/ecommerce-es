import tsParser from "@typescript-eslint/parser";
import tsPlugin from "@typescript-eslint/eslint-plugin";
import importPlugin from "eslint-plugin-import";

/** Ignore patterns for all configs */
const globalIgnores = {
  ignores: [
    ".next/**",
    "out/**",
    "build/**",
    "dist/**",
    "coverage/**",
    ".git/**",
    "node_modules/**"
  ]
};

/** Base TypeScript configuration for packages */
const baseConfig = {
  files: ["packages/**/*.ts", "packages/**/*.tsx"],
  languageOptions: {
    parser: tsParser,
    parserOptions: {
      ecmaVersion: "latest",
      sourceType: "module"
    }
  },
  plugins: {
    "@typescript-eslint": tsPlugin,
    import: importPlugin
  },
  rules: {
    "import/no-self-import": "error",
    "@typescript-eslint/no-explicit-any": "warn"
  },
  settings: {
    "import/extensions": [".ts", ".tsx", ".js"]
  }
};

export default [globalIgnores, baseConfig];
