import { FilterCarByBrandNamePipe } from './filter-car-by-brand-name.pipe';

describe('FilterCarByBrandNamePipe', () => {
  it('create an instance', () => {
    const pipe = new FilterCarByBrandNamePipe();
    expect(pipe).toBeTruthy();
  });
});
