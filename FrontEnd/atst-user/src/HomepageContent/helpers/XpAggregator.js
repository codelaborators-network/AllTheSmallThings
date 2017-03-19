const ADD_EVENT = 100;
const REMOVE_EVENT = 200;

class XpAggregator {
  calculateTotal(events) {
    let total = 0;

    events.forEach((ev) => {
      console.log(ev);
      if (ev.ActionType === ADD_EVENT) total += parseInt(ev.Value);
      if (ev.ActionType === REMOVE_EVENT) total -= parseInt(ev.Value);
    });

    return total;
  }
}

export default new XpAggregator();