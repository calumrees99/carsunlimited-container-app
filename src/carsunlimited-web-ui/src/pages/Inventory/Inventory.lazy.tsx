import React, { lazy, Suspense } from 'react';

const LazyInventory = lazy(() => import('./Inventory'));

const Inventory = (props: JSX.IntrinsicAttributes & { children?: React.ReactNode; }) => (
  <Suspense fallback={null}>
    <LazyInventory {...props} />
  </Suspense>
);

export default Inventory;
