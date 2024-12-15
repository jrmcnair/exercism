class Node<TElement> {
  public next?: Node<TElement>
  public prev?: Node<TElement>
  public readonly element: TElement
  
  constructor(element: TElement) {
    this.element = element
  }
}

export class LinkedList<TElement> {
  private _head?: Node<TElement>
  private _tail?: Node<TElement>

  public push(element: TElement) {
    const node = new Node(element)

    if (!this._tail) {
      this._head = node
      this._tail = node
    } else {
      node.prev = this._tail
      this._tail.next = node
      this._tail = node
    }
  }

  public pop(): TElement {
    if (!this._tail) throw new Error("Cannot pop from an empty list")
    let node = this._tail
    
    if (this._tail?.prev) {
      this._tail = this._tail.prev
      this._tail.next = undefined
    } else {
      this._tail = undefined
      this._head = undefined
    }
    
    return node!.element
  }

  public shift(): TElement {
    if (!this._head) throw new Error("Cannot shift from an empty list")
    let node = this._head

    if (this._head?.next) {
      this._head = this._head.next
      this._head.prev = undefined
    } else {
      this._head = undefined
      this._tail = undefined
    }

    return node!.element
  }

  public unshift(element: TElement) {
    const node = new Node(element)

    if (!this._head) {
      this._head = node
      this._tail = node
    } else {
      node.next = this._head
      this._head.prev = node
      this._head = node
    }
  }

  public delete(element: TElement) {
    let node = this._head
    while (node) {
      if (node.element === element ) {
        if (node === this._head) this._head = this._head.next
        else if (node === this._tail) this._tail = this._tail.prev
        else {
          node.prev!.next = node.next
          node.next!.prev = node.prev
        }
          
        if (node.prev && node.next) node.prev.next = node.next
        else if (node.next) node.next.prev = undefined
        else if (node.prev) node.prev.next = undefined
        
        break;
      }

      node = node?.next
    }
  }

  public count(): number {
    let count = 0

    let node = this._head
    while (node) {
      count++
      node = node?.next
    }
    
    return count
  }
}
