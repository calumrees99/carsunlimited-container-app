import React, { lazy, Suspense } from 'react';

const LazyProduct = lazy(() => import('./Product'));

const Product = (props: JSX.IntrinsicAttributes & { children?: React.ReactNode; }) => (
  <Suspense fallback={null}>
    <LazyProduct {...props} />
  </Suspense>
);

export default Product;
