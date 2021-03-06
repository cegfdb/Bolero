// $begin{copyright}
//
// This file is part of Bolero
//
// Copyright (c) 2018 IntelliFactory and contributors
//
// Licensed under the Apache License, Version 2.0 (the "License"); you
// may not use this file except in compliance with the License.  You may
// obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
// implied.  See the License for the specific language governing
// permissions and limitations under the License.
//
// $end{copyright}

namespace Bolero.Tests.Remoting

open Microsoft.AspNetCore.Mvc.RazorPages
open Microsoft.Extensions.Hosting

type HostModel(env: IHostEnvironment) =
    inherit PageModel()

    static let defaultIsServer = false

    member this.IsServer =
        let mutable queryParam = Unchecked.defaultof<_>
        let mutable parsed = false
        if env.IsDevelopment()
            && this.Request.Query.TryGetValue("server", &queryParam)
            && bool.TryParse(queryParam.[0], &parsed)
        then
            parsed
        else
            defaultIsServer
