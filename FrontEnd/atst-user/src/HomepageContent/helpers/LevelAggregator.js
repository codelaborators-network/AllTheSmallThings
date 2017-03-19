class LevelAggregator {
  calculateTotal(events) {
    console.log('levels', events);
    const lastIndex = events.length - 1;
    return events[lastIndex].Value;
  }
}

export default new LevelAggregator();