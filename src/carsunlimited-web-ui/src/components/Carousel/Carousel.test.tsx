import React from 'react';
import { render, screen } from '@testing-library/react';
import '@testing-library/jest-dom/extend-expect';
import Carousel from './Carousel';

describe('<Carousel />', () => {
  test('it should mount', () => {
    render(<Carousel />);
    
    const carousel = screen.getByTestId('Carousel');

    expect(carousel).toBeInTheDocument();
  });
});