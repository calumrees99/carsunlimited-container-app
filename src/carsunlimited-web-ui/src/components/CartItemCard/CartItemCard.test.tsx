import React from 'react';
import { render, screen } from '@testing-library/react';
import '@testing-library/jest-dom/extend-expect';
import CartItemCard from './CartItemCard';

describe('<CartItemCard />', () => {
  test('it should mount', () => {
    render(<CartItemCard />);
    
    const cartItemCard = screen.getByTestId('CartItemCard');

    expect(cartItemCard).toBeInTheDocument();
  });
});