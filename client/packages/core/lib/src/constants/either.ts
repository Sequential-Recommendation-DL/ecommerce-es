type Left<L> = {
  type: "left";
  value: L;
};

type Right<R> = {
  type: "right";
  value: R;
};

type Either<L, R> = Left<L> | Right<R>;

export { Either };
