import React from 'react';
import { render, screen } from '@testing-library/react';
import '@testing-library/jest-dom/extend-expect';
import LatestProducts from './LatestProducts';

describe('<LatestProducts />', () => {
  test('it should mount', () => {
    render(<LatestProducts name="Products" />);
    
    const latestProducts = screen.getByTestId('LatestProducts');

    expect(latestProducts).toBeInTheDocument();
  });
});