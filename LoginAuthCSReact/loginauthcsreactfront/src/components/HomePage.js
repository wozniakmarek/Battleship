import React, { Component } from 'react'

export default class HomePage extends Component {

  

  render() {
    return (
      <div
        style={{
          height: '100%',
          width: '100%',
          display: 'flex',
          alignItems: 'center',
          justifyContent: 'center',
        }}
      >
        <h1>Welcome To HomePage</h1>
        <h3>UserName : {this.props.location.state.UserName}</h3>
        <h3>Role : {this.props.location.state.Role}</h3>
      </div>
    )
  }
}
