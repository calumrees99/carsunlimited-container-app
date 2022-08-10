import React from 'react';
import { render, screen } from '@testing-library/react';
import '@testing-library/jest-dom/extend-expect';
import CartButton from './CartButton';

describe('<CartButton />', () => {
  test('it should mount', () => {
    render(<CartButton />);
    
    const cartButton = screen.getByTestId('CartButton');

    expect(cartButton).toBeInTheDocument();
  });
});