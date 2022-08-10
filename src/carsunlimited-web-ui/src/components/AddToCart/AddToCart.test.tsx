import React from 'react';
import { render, screen } from '@testing-library/react';
import '@testing-library/jest-dom/extend-expect';
import AddToCart from './AddToCart';

describe('<AddToCart />', () => {
  test('it should mount', () => {
    render(<AddToCart />);
    
    const addToCart = screen.getByTestId('AddToCart');

    expect(addToCart).toBeInTheDocument();
  });
});