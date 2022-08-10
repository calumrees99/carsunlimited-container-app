import React from 'react';
import { render, screen } from '@testing-library/react';
import '@testing-library/jest-dom/extend-expect';
import ProductPageTabs from './ProductPageTabs';

describe('<ProductPageTabs />', () => {
  test('it should mount', () => {
    render(<ProductPageTabs />);
    
    const productPageTabs = screen.getByTestId('ProductPageTabs');

    expect(productPageTabs).toBeInTheDocument();
  });
});